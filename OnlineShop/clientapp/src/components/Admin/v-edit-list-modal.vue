<template>
  <div>
    <b-modal :id="id" :title="title" size="xl" @ok="handleOk">
      <b-container fluid>
        <b-form inline ref="form" @submit.stop.prevent="handleSubmit">
          <b-col v-for="(value, name) in item" :key="name">
            <label class="mr-sm-2" for="inline-form-custom-select-pref">{{
              name
            }}</label>
            <b-form-input
              id="inline-form-input-name"
              v-model="item[name]"
              class="mb-2 mr-sm-2 mb-sm-0"
              @change="handleChange(name, item[name])"
            ></b-form-input>
          </b-col>
        </b-form>
      </b-container>
    </b-modal>
  </div>
</template>

<script>
export default {
  name: "v-edit-list-modal",
  props: {
    editItem: {
      type: Object,
      required: true,
    },
    id: {
      type: String,
      required: true,
    },
    title: {
      type: String,
      required: false,
    },
  },
  methods: {
    handleOk(bvModalEvt) {
      // Prevent modal from closing
      bvModalEvt.preventDefault();
      // Trigger submit handler
      this.handleSubmit();
    },
    handleChange(name, value) {
      this.editModal.item[name] = value;
    },
    handleSubmit() {
      debugger;
      this.$emit("edit-item", {
        item: this.item,
        id: this.item.id,
      });
      this.$nextTick(() => {
        this.$bvModal.hide(this.id);
      });
    },
  },
};
</script>

<style lang="scss" scoped></style>
