import apiClient from './apiClient';

export const authApi = {
  // Login method
  login: async (credentials) => {
    // Expecting credentials to be { email, password }
    return apiClient.post('/auth/login', credentials);
  },

  // Register method
  register: async (userData) => {
    return apiClient.post('/auth/register', userData);
  },

  // Get current user profile
  getProfile: async () => {
    return apiClient.get('/auth/profile');
  },
};
