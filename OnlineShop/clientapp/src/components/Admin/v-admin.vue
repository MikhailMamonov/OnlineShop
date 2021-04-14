<template>
  <b-container>
    <!-- #region-->
    <b-row>
      <h2>Categories</h2>
      <v-add-list-item
        :item="category"
        v-on:add-item="ADD_CATEGORY"
      ></v-add-list-item>
      <b-table
        small
        selectable
        striped
        hover
        :items="categories"
        :fields="categoryFields"
      >
        <template #cell(actions)="row">
          <b-row>
            <b-col>
              <b-button
                size="sm"
                @click="
                  editCategoryClickHandler(row.item, row.index, $event.target)
                "
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
    </b-row>
    <!--#endregion  -->
    <b-row>
      <h2>Products</h2>
      <!-- Product Add -->
      <v-add-list-item
        :item="product"
        v-on:add-item="ADD_PRODUCT"
      ></v-add-list-item>

      <!-- Main Table -->
      <b-table
        small
        selectable
        striped
        hover
        :items="products"
        :fields="productFields"
      >
        <template #cell(actions)="row">
          <b-row>
            <b-col>
              <b-button
                size="sm"
                @click="
                  editProductClickHandler(row.item, row.index, $event.target)
                "
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
    </b-row>

    <b-row>
      <h2>Users</h2>
      <!-- User Add -->
      <v-add-list-item :item="user" v-on:add-item="ADD_USER"></v-add-list-item>

      <!-- Main Table -->
      <b-table
        small
        selectable
        striped
        hover
        :items="users"
        :fields="userFields"
      >
        <template #cell(actions)="row">
          <b-row>
            <b-col>
              <b-button
                size="sm"
                @click="
                  editUserClickHandler(row.item, row.index, $event.target)
                "
                class="mr-1"
                >Edit</b-button
              >
            </b-col>
            <b-col
              ><b-button @click="DELETE_USER(row.item.id)" variant="danger"
                >Delete</b-button
              ></b-col
            >
          </b-row>
        </template>
      </b-table>
    </b-row>
    <!-- Info modal -->
    <v-edit-list-modal
      :editModal="editCategoryModal"
      @edit-item="EDIT_CATEGORY"
    >
    </v-edit-list-modal>
    <v-edit-list-modal :editModal="editProductModal" @edit-item="EDIT_PRODUCT">
    </v-edit-list-modal>
    <v-edit-list-modal :editModal="editUserModal" @edit-item="EDIT_USER">
    </v-edit-list-modal>
  </b-container>
</template>

<script>
import { mapState, mapActions } from "vuex";
import vAddListItem from "./v-add-list-item.vue";
import vEditListModal from "./v-edit-list-modal.vue";

export default {
  name: "v-admin-panel",
  data() {
    return {
      // users: [
      //   { id: 1, name: "Bob", role: "admin" },
      //   { id: 2, name: "Mikki", role: "admin" },
      //   { id: 3, name: "Paul", role: "admin" },
      //   { id: 4, name: "Sarah", role: "admin" },
      // ],
      product: {
        name: { value: "", type: "text" },
        price: { value: 0, type: "number" },
      },
      user: {
        displayName: { value: "", type: "text", validation: function(name){return name.length > 0 && name.length < 13 }, errorMessage:"Name must be 0-12 characters long."},
        email: {
           value: "",
            type: "email",
            validation: function (email) {
               var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
               return re.test(email);},
               errorMessage: "Email field must be correct" },
         password: {
            value: "", 
            type: 'password',
            validation: function(password){
              var re= /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
              return re.test(password);
               },
            errorMessage:"Password must be 6-12 characters long, upper and lower cases and digits."},
      },
      category: {
        name: { value: "", type: "text" },
      },
      productFields: ["name", "price", "actions"],
      categoryFields: ["name", "actions"],
      userFields: ["displayName", "Email", "actions"],
      editCategoryModal: {
        id: "edit-category-modal",
        title: "",
        item: "",
      },
      editProductModal: {
        id: "edit-product-modal",
        title: "",
        item: "",
      },
      editUserModal: {
        id: "edit-user-modal",
        title: "",
        item: "",
      },
    };
  },
  computed: {
    ...mapState({
      products: (state) => state.products.products,
      users: (state) => state.users.users,
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
    ...mapActions("users",["ADD_USER","EDIT_USER", "DELETE_USER"]),

    editProductClickHandler(item, index, button) {
      debugger;
      this.editProductModal.title = `Row index: ${index}`;
      this.editProductModal.item = item;
      this.$root.$emit("bv::show::modal", this.editProductModal.id, button);
    },
    editCategoryClickHandler(item, index, button) {
      debugger;
      this.editCategoryModal.title = `modal id: ${this.editCategoryModal.id}`;
      this.editCategoryModal.item = item;
      this.$root.$emit("bv::show::modal", this.editCategoryModal.id, button);
    },

    editUserClickHandler(item, index, button) {
      debugger;
      this.editUserModal.title = `modal id: ${this.editUserModal.id}`;
      this.editUserModal.item = item;
      this.$root.$emit("bv::show::modal", this.editUserModal.id, button);
    },
  },
  components: { vAddListItem, vEditListModal },
};
</script>

<style lang="scss" scoped></style>
