import apiClient from './apiClient';

export const productApi = {
  // Get list of products (supports filters/pagination)
  getAll: async (params = {}) => {
    return apiClient.get('/shop-products', { params });
  },

  // Get a single product by ID
  getById: async (id) => {
    return apiClient.get(`/shop-products/${id}`);
  },

  // Create a new product
  create: async (productData) => {
    return apiClient.post('/shop-products', productData);
  },

  // Update a product by ID (Full update)
  update: async (id, productData) => {
    return apiClient.put(`/shop-products/${id}`, productData);
  },

  // Partial update
  patch: async (id, partialData) => {
    return apiClient.patch(`/shop-products/${id}`, partialData);
  },

  // Delete product
  delete: async (id) => {
    return apiClient.delete(`/shop-products/${id}`);
  },
};
