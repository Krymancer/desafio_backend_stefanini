<template>
  <div>
    <button class="add-button" @click="show">Add City</button>
    <CityModal :show="cityModal" />
    <CityTable :cities="cities" />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "@vue/runtime-core";
import CityTable from "./CityTable.vue";
import CityModal from "./CityModal.vue";
import { useStore } from "../../store";
import { mapGetters } from "vuex";
import axios from "axios";

export default defineComponent({
  async mounted() {
    const response = await axios({
      method: "GET",
      url: "http://localhost:5000/api/City",
    });
    //
    this.store.commit("setCities", response.data.cities);
  },
  setup() {
    const store = useStore();
    return {
      store,
    };
  },
  components: {
    CityTable,
    CityModal,
  },
  methods: {
    show() {
      this.store.commit("toggleCityModal");
    },
  },
  computed: {
    ...mapGetters({
      cityModal: "getCityModal",
      cities: "getCities",
    }),
  },
});
</script>

<style>
.add-button {
  width: 100%;
  background-color: #49cc90;
}
</style>
