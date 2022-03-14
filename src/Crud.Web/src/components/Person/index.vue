<template>
  <div>
    <button class="add-button" @click="show">Add Person</button>
    <PersonModal :show="personModal" />
    <PersonTable :persons="persons" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "@vue/runtime-core";
import PersonTable from "./PersonTable.vue";
import PersonModal from "./PersonModal.vue";
import { useStore } from "../../store";
import { mapGetters } from "vuex";

export default defineComponent({
  setup() {
    const store = useStore();
    return {
      store,
    };
  },
  components: {
    PersonTable,
    PersonModal,
  },
  methods: {
    show() {
      this.store.commit("togglePersonModal");
    },
  },
  computed: {
    ...mapGetters({
      personModal: "getPersonModal",
      persons: "getPersons",
    }),
  },
});
</script>

<style>
.add-button {
  width: 100%;
  height: 3em;
}
</style>
