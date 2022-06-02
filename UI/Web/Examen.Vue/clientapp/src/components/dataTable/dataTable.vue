<template>
  <v-data-table
    v-model="itemSelected"
    dark
    :search="search"
    :show-select="showSelect"
    :item-key="keyItem"
    :headers="headers"
    :items="items"
    class="elevation-1"
    :footer-props="{
      'items-per-page': 5,
      'items-per-page-text': 'Registros por pagina',
      'items-per-page-all-text': 'Todos',
      'show-current-page': true,
    }"
  >
    <template v-slot:body="{ items, isSelected, select }">
      <tbody>
        <tr v-for="(item, index) in items" :key="index">
          <td class="text-center" v-if="showSelect">
            <v-checkbox
              :input-value="isSelected(item)"
              style="margin: 0px; padding: 0px"
              hide-details
              @change="emitItemSelect(item)"
              @click="select(item, !isSelected(item))"
            >
            </v-checkbox>
          </td>
          <td v-for="header in headers" :key="header.value" :class="headers.length>2?'text-left':'text-center'">
            <span v-if="item[header.value] && header.isCustom==false">{{
              item[header.value]
            }}</span>
            <slot v-else v-bind="item" :name="header.value"></slot>
          </td>
        </tr>
      </tbody>
    </template>
  </v-data-table>
</template>

<script>
export default {
  name: "dataTable",
  data() {
    return {
      itemSelected: [],
    };
  },
  props: {
    items: {
      type: Array,
      required: true,
    },
    headers: {
      type: Array,
      required: true,
    },
    keyItem: {
      type: String,
      required: true,
    },
    showSelect: {
      type: Boolean,
      default: true,
    },
    search: {
      type: String,
      default: '',
    },
    emitItemSelect: {
      type: Function,
      default: () => {},
    },
  },
};
</script>

<style>
</style>