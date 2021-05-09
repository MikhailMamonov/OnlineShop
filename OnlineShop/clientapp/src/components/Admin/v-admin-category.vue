<template>
  <b-row>
    <h2>Categories</h2>
    <v-add-list-item
      :item="category"
      v-on:add-item="ADD_CATEGORY"
    ></v-add-list-item>
    <b-table small :items="categories" :fields="categoryFields">
      <template #cell(name)="data">
        <b-col>{{ data.value }}</b-col>
      </template>
      <template #cell(actions)="data">
        <b-row>
          <b-col>
            <b-button size="sm" @click="editCategory(data.item)" class="mr-1"
              >Edit</b-button
            >
          </b-col>
          <b-col
            ><b-button @click="DELETE_CATEGORY(data.item.id)" variant="danger"
              >Delete</b-button
            ></b-col
          >
        </b-row>
      </template>
    </b-table>
    <b-modal
      ref="editCategoryModal"
      title="edit category"
      v-model="modalShow"
      size="xl"
      @ok.prevent="handleSubmit"
      @close="close"
    >
      <v-edit-form ref="editCategoryForm" :item="editCategoryItem" />
    </b-modal>
  </b-row>
</template>

<script>
import vAddListItem from "./v-add-list-item.vue";
import vEditForm from "./v-edit-form.vue";
import { mapActions } from "vuex";

export default {
  name: "v-admin-category",
  props: ["categories"],
  components: { vAddListItem, vEditForm },

  data() {
    return {
      category: {
        name: {
          value: "",
          type: "text",
          validation: function(name) {
            return name.length > 0 && name.length < 13;
          },
        },
      },
      modalShow: false,
      name: "noname",
      categoryFields: ["name", "actions"],
      editCategoryItem: null,
    };
  },
  methods: {
    ...mapActions("products", [
      "ADD_CATEGORY",
      "EDIT_CATEGORY",
      "DELETE_CATEGORY",
    ]),
    close() {
      this.modalShow = false;
      setTimeout(() => {
        this.editCategoryItem = Object.assign({}, this.formFields);
      }, 300);
    },
    editCategory(data) {
      this.editCategoryItem = JSON.parse(JSON.stringify(data));

      console.log(`editCategoryItem -> ${this.editCategoryItem.name}`);

      this.modalShow = true;
    },
    handleSubmit() {
      const data = this.$refs.editCategoryForm.submit();
      debugger;
      if (data) {
        this.EDIT_CATEGORY({
          item: this.editCategoryItem,
          id: this.editCategoryItem.id,
        });
        this.close();
      }
    },
  },
};
</script>

<style lang="scss" scoped></style>
