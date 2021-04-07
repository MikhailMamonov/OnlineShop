<template>
  <b-row>
    <b-col v-for="(value, name) in item" :key="name">
      <b-input
        v-if="isEditing"
        v-model="item[name]"
        v-on:keyup.enter="onUserSubmit()"
        v-on:blur="onUserSubmit()"
      ></b-input>
      <div v-else v-on:dblclick="isEditing = true">
        {{ value }}
      </div>
    </b-col>

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
