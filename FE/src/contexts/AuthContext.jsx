import React, { createContext, useContext, useState, useEffect } from 'react';
import { LOCAL_STORAGE_KEYS } from '../constants';
import { authApi } from '../api/authApi';

const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Restore user session on application load
  useEffect(() => {
    const initializeAuth = async () => {
      const storedToken = localStorage.getItem(LOCAL_STORAGE_KEYS.TOKEN);
      const storedUser = localStorage.getItem(LOCAL_STORAGE_KEYS.USER);

      if (storedToken && storedUser) {
        try {
          setUser(JSON.parse(storedUser));
          // Optionally, verify token validity with backend
          // const profile = await authApi.getProfile();
          // setUser(profile.data);
        } catch (err) {
          console.error("Failed to restore session:", err);
          logout();
        }
      }
      setLoading(false);
    };

    initializeAuth();
  }, []);

  // Login handler
  const login = async (email, password) => {
    setError(null);
    setLoading(true);
    try {
      const response = await authApi.login({ email, password });
      // Depending on C# API design, suppose response is { data: { token, user } } or directly { token, user }
      const { token, user: userData } = response.data || response || {};
      
      if (token) {
        localStorage.setItem(LOCAL_STORAGE_KEYS.TOKEN, token);
        if (userData) {
          localStorage.setItem(LOCAL_STORAGE_KEYS.USER, JSON.stringify(userData));
          setUser(userData);
        } else {
          // If BE only returns token, set a dummy user or fetch profile
          const dummyUser = { email, name: email.split('@')[0] };
          localStorage.setItem(LOCAL_STORAGE_KEYS.USER, JSON.stringify(dummyUser));
          setUser(dummyUser);
        }
        return true;
      }
      throw new Error("Invalid response format: token not found");
    } catch (err) {
      const errorMsg = err.message || 'Login failed. Please check credentials.';
      setError(errorMsg);
      throw err;
    } finally {
      setLoading(false);
    }
  };

  // Logout handler
  const logout = () => {
    localStorage.removeItem(LOCAL_STORAGE_KEYS.TOKEN);
    localStorage.removeItem(LOCAL_STORAGE_KEYS.USER);
    setUser(null);
    setError(null);
  };

  const value = {
    user,
    loading,
    error,
    login,
    logout,
    isAuthenticated: !!user,
  };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
};

// Custom hook to consume the AuthContext easily
export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};
