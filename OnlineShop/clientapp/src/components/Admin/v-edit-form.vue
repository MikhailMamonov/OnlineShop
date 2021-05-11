<template>
  <div>
    <b-form ref="form" @submit.prevent="submit">
      <b-form-group
        v-for="(value, name, index) in item"
        :key="index"
        :label="name"
        :label-for="`input-${name}`"
        invalid-feedback="{name} is required"
      >
        <b-form-input
          :id="`input-${name}`"
          :v-model="newItem[name]"
          :value="value"
        ></b-form-input>
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
    newItem() {
      return this.item;
    },
  },
  methods: {
    submit() {
      debugger;
      return this.newItem;
    },
  },
};
</script>
