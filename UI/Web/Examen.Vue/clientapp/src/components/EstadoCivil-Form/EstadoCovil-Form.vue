<template>
  <v-form>
    <v-text-field label="Estado civil" type="text"></v-text-field>
  </v-form>
</template>

<script>
export default {
  props: {
    action: {
      type: String,
      default: "nuevo",
    },
    readOnly: {
      type: Boolean,
      default: false,
    },
    isValid: {
      type: Function,
      default: () => {},
    },
  },
};
</script>

<style>
</style>