export const getters = {
  PRODUCTS_BY_CATEGORY(state, categoryId) {
    return state.products.filter((p) => p.categoryId == categoryId);
  },
};
