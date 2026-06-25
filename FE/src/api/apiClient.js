import axios from 'axios';
import { API_BASE_URL, LOCAL_STORAGE_KEYS } from '../constants';

// Create a configured Axios instance
const apiClient = axios.create({
  baseURL: API_BASE_URL,
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor: Attach JWT token from localStorage automatically if it exists
apiClient.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem(LOCAL_STORAGE_KEYS.TOKEN);
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

// Response interceptor: Handle common errors globally (e.g. 401 Unauthorized)
apiClient.interceptors.response.use(
  (response) => {
    // Return data directly to simplify response handling in components
    return response.data;
  },
  (error) => {
    // Global error response handling
    if (error.response) {
      const { status } = error.response;
      
      if (status === 401) {
        // Token expired or invalid, clear storage and optionally redirect to login
        localStorage.removeItem(LOCAL_STORAGE_KEYS.TOKEN);
        localStorage.removeItem(LOCAL_STORAGE_KEYS.USER);
        
        // You can dispatch a logout action or redirect to login page here if needed
        console.warn('Unauthorized! Logging out user...');
      }
      
      // Return custom structured error details to be caught in API calling methods
      return Promise.reject({
        status,
        message: error.response.data?.message || 'Something went wrong',
        data: error.response.data,
      });
    }
    
    return Promise.reject({
      status: 500,
      message: error.message || 'Network error occurred',
    });
  }
);

export default apiClient;
