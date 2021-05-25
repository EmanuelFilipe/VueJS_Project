<template>
  <div id="app">
    <Alunos />
  </div>
</template>

<script>
import Alunos from './components/Aluno/Alunos.vue'

export default {
  name: 'App',
  components: {
    Alunos
  }
}
</script>

<style>
@import url("https://fonts.googleapis.com/css?family=Montserrat:400,700");

body{
  margin: 0;
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

body, html{
  margin: 0;
  height: 100%;
}

table{
  margin: 0px;
  padding: 0px;
  list-style-type: none;
  width: 100%;
}

table thead th {
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px 0px; 
  text-align: center !important;
}

table tr td {
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}

.colPequeno {
  width: 5%;
}

.btn {

  border: 1px solid black;
  border-bottom: 3px solid black;
  border-radius: 5px;
  color: white;
  font-weight: bold;
  padding: 10px 20px;
  cursor: pointer;

}

.btn:hover {
  text-shadow: 1px 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}

.btn-danger{
    background-color: #fa4430;
}

#app {

}
</style>
