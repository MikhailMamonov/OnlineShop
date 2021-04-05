<template>
  <b-container class="bv-example-row">
    <h2>Categories</h2>
    <b-row>
      <b-form inline>
        <label for="inline-form-input-category_name">Name</label>
        <b-form-input
          id="inline-form-input-category_name"
          class="mb-2 mr-sm-2 mb-sm-0"
          placeholder="Category name"
          v-model="category.name"
        ></b-form-input>
        <b-button @click="addCategory()" variant="primary">Save</b-button>
      </b-form>
    </b-row>
    <b-row>
      <b-list-group>
        <b-list-group-item v-for="c in categories" :key="c.id">
          <v-admin-list-item
            :item="c"
            v-on:delete-item="DELETE_CATEGORY"
            v-on:save-item="EDIT_CATEGORY"
          ></v-admin-list-item>
        </b-list-group-item>
      </b-list-group>
    </b-row>

    <h2>Products</h2>
    <b-row>
      <b-form inline>
        <label for="inline-form-input-name">Name</label>
        <b-form-input
          id="inline-form-input-name"
          class="mb-2 mr-sm-2 mb-sm-0"
          placeholder="Product name"
          v-model="product.name"
        ></b-form-input>
        <label class="sr-only" for="inline-form-input-price">Price</label>
        <b-input-group prepend="$" class="mb-2 mr-sm-2 mb-sm-0">
          <b-form-input
            id="inline-form-input-price"
            placeholder="Price"
            v-model="product.price"
          ></b-form-input>
        </b-input-group>
        <b-button @click="addProduct()" variant="primary">Save</b-button>
      </b-form>
    </b-row>
    <b-row>
      <b-list-group>
        <b-list-group-item v-for="p in products" :key="p.id">
          <v-admin-list-item
            :item="p"
            v-on:delete-item="DELETE_PRODUCT"
            v-on:save-item="EDIT_PRODUCT"
          ></v-admin-list-item>
        </b-list-group-item>
      </b-list-group>
    </b-row>
  </b-container>
</template>

<script>
import { mapState, mapActions } from "vuex";
import vAdminListItem from "./v-admin-list-item.vue";

export default {
  name: "v-admin-panel",
  data() {
    return {
      users: ["bob", "Mikki", "Paul", "Sara"],
      product: {
        name: "",
        price: 0,
      },
      category: {
        name: "",
      },
    };
  },
  computed: {
    ...mapState({
      products: (state) => state.products.products,
      categories: (state) => state.products.categories,
    }),
  },
  mounted() {
    console.log(this.categories);
  },
  methods: {
    ...mapActions("products", [
      "ADD_PRODUCT",
      "ADD_CATEGORY",
      "EDIT_PRODUCT",
      "EDIT_CATEGORY",
      "DELETE_PRODUCT",
      "DELETE_CATEGORY",
    ]),
    deleteThisRow(data) {
      switch (data.collName) {
        case "categories":
          this.categories.splice(data.index, 1);
          break;
        case "products":
          this.products.splice(data.index, 1);
          break;
        case "users":
          this.users.splice(data.index, 1);
          break;
        default:
          return;
      }
    },
    saveThisRow(data) {
      console.log("before edit", this.categories, this.products, this.users);

      switch (data.collName) {
        case "categories":
          this.categories[data.index] = data.name;
          break;
        case "products":
          this.products[data.index] = data.name;
          break;
        case "users":
          this.users[data.index] = data.name;
          break;
      }
      console.log("after edit", this.categories, this.products, this.users);
    },
    addProduct() {
      const formData = new FormData();
      formData.append("name", this.product.name);
      formData.append("price", this.product.price);
      this.ADD_PRODUCT(formData);
    },
    addCategory() {
      const formData = new FormData();
      formData.append("name", this.category.name);
      this.ADD_CATEGORY(formData);
    },
  },
  components: { vAdminListItem },
};
</script>

<style lang="scss" scoped></style>
