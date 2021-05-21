<template>
  <div>
    <h1>{{nome}}</h1>
  </div>
</template>

<script>
export default {
  //o data sempre tem que ter um return
  data(){
    return {
      nome: "Alunos"
    }
  },
  props: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
