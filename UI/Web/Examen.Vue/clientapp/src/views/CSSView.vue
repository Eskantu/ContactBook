<template>
  <div>
    <CSS :titles="items"> </CSS>
  </div>
</template>

<script>
import CSS from "./CSS.vue";
export default {
  name: "CSSView",
  components: { CSS },
  data() {
    return {
      items: [
        {
          title: "Forky",
          view: "Forky",
        },
        {
          title: "Registro",
          view: "Registro",
        },
        {
          title: "Projects",
          view: "Proyectos",
          
        },
      ],
    };
  },
};
</script>