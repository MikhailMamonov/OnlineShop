<template>
  <b-container>
    <!-- #region-->
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
    <b-table
      small
      selectable
      striped
      hover
      :items="categories"
      :fields="categoryFields"
      @row-dblclicked="editClickHandler"
    >
      <template #cell(actions)="row">
        <b-row>
          <b-col>
            <b-button
              size="sm"
              @click="editClickHandler(row.item, row.index, $event.target)"
              class="mr-1"
              >Edit</b-button
            >
          </b-col>
          <b-col
            ><b-button @click="DELETE_CATEGORY(row.item.id)" variant="danger"
              >Delete</b-button
            ></b-col
          >
        </b-row>
      </template>
    </b-table>
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
    <!--#endregion  -->
    <h2>Products</h2>
    <!-- Product Add -->
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
    <!-- Main Table -->
    <b-table
      small
      selectable
      striped
      hover
      :items="products"
      :fields="productFields"
      @row-dblclicked="editClickHandler"
    >
      <template #cell(actions)="row">
        <b-row>
          <b-col>
            <b-button
              size="sm"
              @click="editClickHandler(row.item, row.index, $event.target)"
              class="mr-1"
              >Edit</b-button
            >
          </b-col>
          <b-col
            ><b-button @click="DELETE_PRODUCT(row.item.id)" variant="danger"
              >Delete</b-button
            ></b-col
          >
        </b-row>
      </template>
    </b-table>
    <!-- Info modal -->
    <b-modal
      :id="editModal.id"
      :title="editModal.title"
      size="xl"
      @ok="handleOk"
    >
      <b-container fluid>
        <b-form inline ref="form" @submit.stop.prevent="handleSubmit">
          <b-col v-for="(value, name) in editModal.item" :key="name">
            <label class="mr-sm-2" for="inline-form-custom-select-pref">{{
              name
            }}</label>
            <b-form-input
              id="inline-form-input-name"
              v-model="editModal.item[name]"
              class="mb-2 mr-sm-2 mb-sm-0"
            ></b-form-input>
          </b-col>
        </b-form>
      </b-container>
    </b-modal>
    <!-- <b-row>
      <b-list-group>
        <b-list-group-item v-for="p in products" :key="p.id">
          <v-admin-list-item
            :item="p"
            v-on:delete-item="DELETE_PRODUCT"
            v-on:save-item="EDIT_PRODUCT"
          ></v-admin-list-item>
        </b-list-group-item>
      </b-list-group>
    </b-row> -->
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
      productFields: ["name", "price", "categoryId", "actions"],
      categoryFields: ["name"],
      isEditing: false,
      editModal: {
        id: "edit-modal",
        title: "",
        item: "",
      },
    };
  },
  computed: {
    ...mapState({
      products: (state) => state.products.products,
      categories: (state) => state.products.categories,
    }),
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
    editClickHandler(item, index, button) {
      debugger;
      this.editModal.title = `Row index: ${index}`;
      this.editModal.item = item;
      this.$root.$emit("bv::show::modal", this.editModal.id, button);
    },
    handleOk(bvModalEvt) {
      // Prevent modal from closing
      bvModalEvt.preventDefault();
      // Trigger submit handler
      this.handleSubmit();
    },
    handleSubmit() {
      debugger;
      this.EDIT_PRODUCT({
        item: this.editModal.item,
        id: this.editModal.item.id,
      });
      this.$nextTick(() => {
        this.$bvModal.hide(this.editModal.id);
      });
    },
    resetEditModal() {
      this.editModal.title = "";
      this.editModal.item = "";
    },
  },
  components: { vAdminListItem },
};
</script>

<style lang="scss" scoped></style>
