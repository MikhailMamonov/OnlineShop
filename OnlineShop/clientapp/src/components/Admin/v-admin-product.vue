<template>
  <b-row>
    <h2>Products</h2>
    <!-- Product Add -->
    <v-add-product-item
      :item="product"
      v-on:add-item="ADD_PRODUCT"
    ></v-add-product-item>

    <!-- Main Table -->
    <b-table
      small
      selectable
      striped
      hover
      :items="products"
      :fields="productFields"
    >
      <template #cell(name)="data">
        <b-col>{{ data.value }}</b-col>
      </template>
      <template #cell(actions)="row">
        <b-row>
          <b-col>
            <b-button size="sm" @click="editProduct(row.item)" class="mr-1"
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
    <b-modal
      ref="editProductModal"
      v-model="showModal"
      title="edit product"
      size="xl"
      @ok.prevent="handleSubmit"
      @close="close"
    >
      <v-edit-form ref="editProductForm" :item="editProductItem" />
    </b-modal>
  </b-row>
</template>

<script>
import vAddProductItem from "./v-add-list-item";
import vEditForm from "./v-edit-form.vue";
import { mapActions } from "vuex";

export default {
  name: "v-admin-product",
  props: {
    products: {
      type: Array,
      default: null,
    },
  },
  data() {
    return {
      product: {
        name: {
          value: "",
          type: "text",
          validation: function(name) {
            return name.length > 0 && name.length < 13;
          },
        },
        price: {
          value: 0,
          type: "number",
          validation: function(price) {
            return price > 0;
          },
        },
      },
      productFields: ["name", "price", "actions"],
      editProductItem: null,
      showModal: false,
    };
  },
  methods: {
    ...mapActions("products", [
      "ADD_PRODUCT",
      "EDIT_PRODUCT",
      "DELETE_PRODUCT",
    ]),
    editProduct(item) {
      this.editProductItem = JSON.parse(JSON.stringify(item));
      debugger;
      this.showModal = true;
    },
    handleSubmit() {
      debugger;
      const data = this.$refs.editProductForm.submit();
      if (data) {
        this.EDIT_PRODUCT({
          item: this.editProductItem,
          id: this.editProductItem.id,
        });
      }
      this.close();
    },
    close() {
      this.showModal = false;
      setTimeout(() => {
        this.editProductItem = Object.assign({}, this.formFields);
      }, 300);
    },
  },
  components: { vAddProductItem, vEditForm },
};
</script>

<style lang="scss" scoped></style>
