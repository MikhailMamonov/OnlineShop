<template>
  <b-row>
    <b-col v-if="isEditing">
      <b-input
        v-model="item.name"
        v-on:keyup.enter="onUserSubmit()"
        v-on:blur="onUserSubmit()"
      ></b-input>
      <b-input></b-input>
    </b-col>
    <b-col v-else v-on:dblclick="isEditing = true">{{ item.name }} </b-col>
    <b-col><b-button @click="editRow()">Edit</b-button></b-col>
    <b-col
      ><b-button @click="$emit('delete-item', item.id)" variant="danger"
        >Delete</b-button
      ></b-col
    >
  </b-row>
</template>

<script>
export default {
  name: "admin-list-item",
  data() {
    return {
      isEditing: false,
    };
  },
  props: {
    item: {
      type: Object,
      default: null,
    },
  },
  methods: {
    editRow() {
      this.isEditing = true;
    },
    onUserSubmit: function() {
      this.isEditing = false;
      this.$emit("save-item", { item: this.item, id: this.item.id });
    },
  },
};
</script>

<style lang="scss" scoped></style>
