<template>
  <b-row>
    <b-col v-if="isEditing">
      <b-input
        v-model="category.name"
        v-on:input="onUserChange"
        v-on:keyup.enter="isEditing = false"
      ></b-input>
    </b-col>
    <b-col v-else>{{ category.name }} </b-col>
    <b-col><b-button @click="editRow()">Edit</b-button></b-col>
    <b-col
      ><b-button
        @click="$emit('delete-category', { index, id: category.id })"
        variant="danger"
        >Delete</b-button
      ></b-col
    >
  </b-row>
</template>

<script>
export default {
  name: "admin-item-category",
  data() {
    return {
      isEditing: false,
    };
  },
  props: {
    category: {
      type: Object,
      default: null,
    },
  },
  methods: {
    editRow() {
      this.isEditing = true;
    },
    onUserChange: function() {
      this.$emit("save-category", { category: this.category });
    },
  },
};
</script>

<style lang="scss" scoped></style>
