<template>
  <div>
    <b-modal
      :id="editModal.id"
      :title="editModal.title"
      size="xl"
      @ok="handleOk"
    >
      <b-container fluid>
        <b-form inline ref="form" @submit.stop.prevent="handleSubmit">
          <b-col v-for="(value, name) in editModal.item" :key="name">
            <label class="mr-sm-2" for="inline-form-custom-select-pref">{{
              name
            }}</label>
            <b-form-input
              id="inline-form-input-name"
              v-model="editModal.item[name]"
              class="mb-2 mr-sm-2 mb-sm-0"
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
    editModal: {
      type: Object,
      required: true,
    },
  },
  methods: {
    handleOk(bvModalEvt) {
      // Prevent modal from closing
      bvModalEvt.preventDefault();
      // Trigger submit handler
      this.handleSubmit();
    },
    handleSubmit() {
      debugger;
      this.$emit("edit-item", {
        item: this.editModal.item,
        id: this.editModal.item.id,
      });
      this.$nextTick(() => {
        this.$bvModal.hide(this.editModal.id);
      });
    },
  },
};
</script>

<style lang="scss" scoped></style>
