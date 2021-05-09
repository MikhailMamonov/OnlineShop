<template>
  <div>
    <b-form ref="form" @submit.prevent="submit">
      <b-form-group
        label="Name"
        label-for="input-name"
        invalid-feedback="Name is required"
      >
        <b-form-input id="input-name" v-model="item.name"></b-form-input>
      </b-form-group>
    </b-form>
  </div>
</template>

<script>
export default {
  props: {
    item: {
      type: Object,
      default: null,
    },
  },
  computed: {
    editedItem() {
      return this.item;
    },
  },
  methods: {
    submit() {
      return this.editedItem;
    },
  },
};
</script>
