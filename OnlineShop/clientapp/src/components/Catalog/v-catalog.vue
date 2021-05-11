<template>
  <b-container class="bv-example-row">
    <!-- <v-catalog-marketing> </v-catalog-marketing> -->
    <h3 align="left">Categories</h3>
    <b-button-group>
      <b-button
        v-for="category in categories"
        :key="category.id"
        @click="changeSelected(category.id)"
        border-variant="primary"
      >
        {{ category.name }}
      </b-button>
    </b-button-group>
    <h3>All Products</h3>
    <b-row>
      <b-card v-for="product in filteredProducts" :key="product.id">
        <b-card-text>{{ product.name }} </b-card-text>
      </b-card>
    </b-row>
    <h3>Best Products</h3>
    <b-row>
      <b-card v-for="product in filteredProducts" :key="product.id">
        <b-card-text>{{ product.id }} </b-card-text>
      </b-card>
    </b-row>
  </b-container>
</template>

<script>
// import vCatalogMarketing from "./v-catalog-marketing.vue";
import { mapState, mapGetters } from "vuex";

export default {
  name: "v-catalog",
  data() {
    return {
      filteredProducts: [],
    };
  },
  // components: { vCatalogMarketing },
  computed: {
    ...mapState({
      categories: (state) => state.products.categories,
      products: (state) => state.products.products,
    }),
    ...mapGetters({ productsByCategory: "products/PRODUCTS_BY_CATEGORY" }),
  },
  methods: {
    changeSelected(categoryId) {
      debugger;
      this.filteredProducts = this.productsByCategory(categoryId);
    },
  },
};
</script>

<style lang="scss" scoped></style>
