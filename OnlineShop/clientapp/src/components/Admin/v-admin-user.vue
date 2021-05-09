<template>
  <b-row>
    <h2>Users</h2>
    <!-- User Add -->
    <v-add-user-item :item="user" v-on:add-item="ADD_USER"></v-add-user-item>

    <!-- Main Table -->
    <b-table small selectable striped hover :items="users" :fields="userFields">
      <template #cell(actions)="row">
        <b-row>
          <b-col>
            <b-button
              size="sm"
              @click="editUser(row.item, row.index, $event.target)"
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
    <b-modal
      ref="editUserModal"
      title="edit user"
      v-model="modalShow"
      size="xl"
      @ok.prevent="handleSubmit"
      @close="close"
    >
      <v-edit-form ref="editUserForm" :item="editItem" />
    </b-modal>
  </b-row>
</template>

<script>
import vAddUserItem from "./v-add-list-item";
import { mapActions } from "vuex";
import vEditForm from "./v-edit-form.vue";

export default {
  name: "v-admin-user",
  props: {
    users: {
      type: Array,
      default: null,
    },
  },
  data() {
    return {
      user: {
        displayName: {
          value: "",
          type: "text",
          validation: function(name) {
            return name.length > 0 && name.length < 13;
          },
          errorMessage: "Name must be 0-12 characters long.",
        },
        email: {
          value: "",
          type: "email",
          validation: function(email) {
            var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
          },
          errorMessage: "Email field must be correct",
        },
        password: {
          value: "",
          type: "password",
          validation: function(password) {
            var re = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;
            return re.test(password);
          },
          errorMessage:
            "Password must be 6-12 characters long, upper and lower cases and digits.",
        },
      },
      modalShow: false,
      editItem: null,
      userFields: ["displayName", "Email", "actions"],
    };
  },
  methods: {
    ...mapActions("users", ["ADD_USER", "EDIT_USER", "DELETE_USER"]),
    editUser(item) {
      this.editItem = JSON.parse(JSON.stringify(item));
      debugger;
      this.modalShow = true;
    },
    handleSubmit() {
      const data = this.$refs.editUserForm.submit();
      debugger;
      if (data) {
        this.EDIT_USER({
          item: this.editItem,
          id: this.editItem.id,
        });
        this.close();
      }
    },
    close() {
      this.modalShow = false;
      setTimeout(() => {
        this.editItem = Object.assign({}, this.formFields);
      }, 300);
    },
  },
  components: { vAddUserItem, vEditForm },
};
</script>

<style lang="scss" scoped></style>
