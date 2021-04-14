<template>
  <b-form inline>
    <b-col v-for="(value, key) in item" :key="key">
      <label for="inline-form-input-name">{{ key }}</label>
      <b-form-input
        class="mb-2 mr-sm-2 mb-sm-0"
        :type="item[key].type"
        v-model="item[key].value"
        :state="item[key].validation(item[key].value)"
      ></b-form-input>
      <b-form-invalid-feedback :state="item[key].validation(item[key].value)">
        {{item[key].errorMessage}}
      </b-form-invalid-feedback>
      <b-form-valid-feedback :state="item[key].validation(item[key].value)">
        Looks Good.
      </b-form-valid-feedback>
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
        console.log(`${key} -> ${this.item[key].value}`);
        if (this.item.hasOwnProperty(key)) {
          formData.append(key, this.item[key].value);
        }
      }
      this.$emit("add-item", formData);
    },
  },
};
</script>

<style lang="scss" scoped></style>
