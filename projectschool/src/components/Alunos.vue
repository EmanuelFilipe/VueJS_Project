<template>
  <div>
    <h1>{{titulo}}</h1>
    <div>
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()">&nbsp;
      <button class="btn btn-input" @click="addAluno()">Adicionar</button>
    </div>
    
    <div style="margin-top: 10px;">
      <table border="1px">
        <thead>
          <th>Mat.</th>
          <th>Nome</th>
          <th>Opções</th>
        </thead>
        <tbody>
          <!-- :key="index" cada linha da tabela terá uma chave distinta -->
          <tr v-for="(aluno, index) in alunos" :key="index">
            <td>{{index + 1}}</td>
            <!-- <td>{{aluno.id}}</td> -->
            <td>{{aluno.nome}}</td>
            <td>
              <button class="btn btn-danger" @click="remover(aluno)">Remover</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
export default {
  //o data sempre tem que ter um return
  data(){
    return {
      titulo: 'Aluno',
      nome: '',
      alunos: [
        { id: 1, nome: 'Filipe' }, { id: 2, nome: 'Lucas' }, { id: 3, nome: 'Gustavo' }
      ]
    }
  },
  props: {
  },
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome
      }
      this.alunos.push(_aluno);
      this.nome = '';
    },

    remover(aluno){
       let indice = this.alunos.indexOf(aluno);
       this.alunos.splice(indice, 1);
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  input{
    border: 0;
    padding: 20px;
    font-size: 1.3em;
    color: #687f7f;
    display: inline;
  }

  .btn-input{
    border: 0px;
    padding: 20px;
    font-size: 1.3em;
    background-color: rgb(116, 115, 115);
    display: inline;
  }

  .btn-input:hover{
    padding: 20px;
    margin: 0px;
    border: 0px;
  }
</style>
