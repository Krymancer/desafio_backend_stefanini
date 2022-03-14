<template>
  <div class="person-modal" v-if="show">
    <div class="person-form">
      <div class="person-inputs">
        <input type="text" placeholder="Name..." v-model="cityData.name" />
        <input type="text" placeholder="UF..." v-model="cityData.uf" />
      </div>
      <div class="person-actions">
        <button @click="sendRequest">Submit</button>
        <button class="delete" @click="cancel">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "@vue/runtime-core";
import axios from "axios";
import { useStore } from "../../store";
import { mapGetters } from "vuex";

export default defineComponent({
  setup() {
    const store = useStore();
    return {
      store,
    };
  },
  data() {
    return {
      cityData: {
        name: "",
        uf: "",
      },
      style: true,
    };
  },
  props: {
    show: {
      type: Boolean,
      default: false,
    },
  },
  computed: {
    ...mapGetters({
      cities: "getCities",
      editFlag: "getEditFlag",
      editId: "getEditId",
      cityEdit: "getCitieEdit",
      cityModal: "getCityModal",
    }),
  },
  methods: {
    async sendRequest() {
      const data = this.cityData;
      console.log(this.editFlag);
      if (this.editFlag) {
        await axios({
          method: "PUT",
          url: `http://localhost:52374/api/City/${this.editId}`,
          data,
        });

        this.store.commit("toggleEdit");
        const mp = this.store.state.cities;
        const np = mp.map((item) => {
          console.log(item);
          if (item.id === this.editId) {
            item = {
              ...data,
              id: this.editId,
            };
          }
          return item;
        });
        this.store.commit("setCities", np);
        this.store.commit("toggleCityModal");
        this.cityData = {
          name: "",
          uf: "",
        };
        this.store.commit("setEditCity", this.cityData);
      } else {
        const response = await axios({
          method: "POST",
          url: "http://localhost:52374/api/City",
          data,
        });

        const mp = this.store.state.cities;

        mp.push({
          ...data,
          id: response.data.id as string,
        });
        this.store.commit("setCities", mp);

        this.cityData = {
          name: "",
          uf: "",
        };
        this.store.commit("setEditCity", this.cityData);
        this.store.commit("toggleCityModal");
      }
      //window.location.reload();
    },
    cancel() {
      this.cityData = {
        name: "",
        uf: "",
      };
      this.store.commit("setEditCity", this.cityData);
      this.store.commit("toggleCityModal");
    },
  },
});
</script>

<style>
.person-modal {
  position: absolute;
  top: 0;
  left: 0;
  z-index: 1;
  display: flex;
  align-items: center;
  justify-content: center;

  margin: 0 !important;

  width: 100%;
  height: 100%;

  background-color: rgba(0, 0, 0, 0.4);
}

.person-form {
  display: flex;
  flex-direction: column;
  background-color: white;
  padding: 1em;
  gap: 0.5em;
}

.person-inputs {
  display: flex;
  flex-direction: column;
  gap: 0.5em;
}

.person-actions {
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 1em;
}

.delete {
  background-color: #f93e3e;
}

/* .person-inputs > input {
}

.person-actions > button {
} */
</style>
