<template>
  <b-form inline>
    <b-col v-for="(value, key) in item" :key="key">
      <label for="inline-form-input-name">{{ key }}</label>
      <b-form-input
        class="mb-2 mr-sm-2 mb-sm-0"
        v-model="item[key]"
      ></b-form-input>
    </b-col>
    <b-button @click="addItem()" variant="primary">ADD</b-button>
  </b-form>
</template>

<script>
export default {
  name: "v-add-list-item",
  data() {
    return {};
  },
  props: {
    item: {
      type: Object,
      default: null,
    },
  },
  methods: {
    addItem() {
      const formData = new FormData();
      for (var key in this.item) {
        console.log(`${key} -> ${this.item[key]}`);
        if (this.item.hasOwnProperty(key)) {
          formData.append(key, this.item[key]);
        }
      }
      this.$emit("add-item", formData);
    },
  },
};
</script>

<style lang="scss" scoped></style>
