<template>
  <div>
    <!-- ao colocar o bind a expressão vira automaticamente javascript -->
    <Titulo :texto="professorid != undefined ? 'Professor(a): ' + professor.nome : 'Todos os Alunos'" />
    <div v-if="professorid != undefined">
      <input type="text" placeholder="Nome do Aluno" v-model="nome" @keyup.enter="addAluno()">&nbsp;
      <button class="btn btn-input" @click="addAluno()">Adicionar</button>
    </div>
    <div style="margin-top: 10px;">
      <table>
        <thead>
          <th>Mat.</th>
          <th>Nome</th>
          <th>Opções</th>
        </thead>
        <tbody v-if="alunos.length">
          <!-- :key="index" cada linha da tabela terá uma chave distinta -->
          <tr v-for="(aluno, index) in alunos" :key="index">
            <td>{{aluno.id}}</td>
            <router-link :to="`/AlunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
              {{aluno.nome}} {{aluno.sobrenome}}
            </router-link>
            <td>
              <button class="btn btn-danger" @click="remover(aluno)">Remover</button>
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          <tr><td colspan="3">Nenhum Aluno encontrado</td></tr>
        </tfoot>
      </table>
    </div>
  </div>

</template>

<script>
import Titulo from '../_Shared/Titulo.vue'

export default {
  components: {
    Titulo
  },
  data(){
    return {
      titulo: 'Aluno',
      professorid: this.$route.params.prof_id, //pegando parametro na rota pelo nome 
      professor: {},
      nome: '',
      alunos: []
    }
  },
  created(){
    if (this.professorid) { 
      this.carregarProfessores();
      this.$http.get('http://localhost:3000/alunos?professor.id=' + this.professorid)
                .then(res => res.json())
                .then(alunos => this.alunos = alunos) //alunos é o retorno da linha acima 'res.json()'
    }
    else {
      this.$http.get('http://localhost:3000/alunos')
                .then(res => res.json())
                .then(alunos => this.alunos = alunos) //alunos é o retorno da linha acima 'res.json()'
    }
  },
  props: {
  },
  methods: {
    addAluno() {
      let _aluno = { 
        nome: this.nome,
        sobrenome: '',
        professor: {
          id: this.professor.id,
          nome: this.professor.nome
        }
      }

      this.$http.post('http://localhost:3000/alunos', _aluno)
                .then(res => res.json())
                .then(aluno => {
                  this.alunos.push(aluno);
                  this.nome = '';
                })
    },
    remover(aluno){
      this.$http.delete(`http://localhost:3000/alunos/${aluno.id}`)
                .then(() => {
                  let indice = this.alunos.indexOf(aluno);
                  this.alunos.splice(indice, 1);
                })
    },
    carregarProfessores() {
       this.$http
           .get("http://localhost:3000/professores/" + this.professorid)
           .then((res) => res.json())
           .then(professor => {
              this.professor = professor
            }); 
    }
  },
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
input{
    width: calc(100% - 195px);
    border: 0;
    padding: 20px;
    font-size: 1.3em;
    color: #687f7f;
    display: inline;
  }

  .btn-input{
    width: 150px;
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
