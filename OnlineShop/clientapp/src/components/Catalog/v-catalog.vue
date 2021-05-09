<template>
  <b-container class="bv-example-row">
    <v-catalog-marketing> </v-catalog-marketing>
    <h3 align="left">Categories</h3>
    <b-row>
      <b-card-group columns>
        <b-card
          v-for="category in categories"
          :key="category.id"
          border-variant="primary"
        >
          <b-card-text>{{ category.name }}</b-card-text>
        </b-card>
      </b-card-group>
    </b-row>
    <h3>Best Products</h3>
    <b-row>
      <b-cart-group>
        <b-card v-for="product in products" :key="product.id">
          <b-card-text>{{ product.name }} </b-card-text>
        </b-card>
      </b-cart-group>
    </b-row>
  </b-container>
</template>

<script>
import vCatalogMarketing from "./v-catalog-marketing.vue";
import { mapState } from "vuex";

export default {
  name: "v-catalog",
  props: {},
  components: { vCatalogMarketing },
  computed: {
    ...mapState({
      categories: (state) => state.products.categories,
      products: (state) => state.products.products,
    }),
  },
};
</script>

<style lang="scss" scoped></style>
