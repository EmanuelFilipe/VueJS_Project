<template>
  <div>
    <Titulo texto="Professores" />
    <div style="margin-top: 10px;">
      <table>
        <thead>
          <th>Cód.</th>
          <th>Nome</th>
          <th>Alunos</th>
        </thead>
        <tbody v-if="Professores.length">
          <!-- :key="index" cada linha da tabela terá uma chave distinta -->
          <tr v-for="(professor, index) in Professores" :key="index">
            <td>{{ professor.id }}</td>
            <!-- tag="td" informa que esse elemento HTML é um td -->
            <router-link v-bind:to="`/alunos/${professor.id}`" tag="td" style="cursor: pointer;">
              {{ professor.nome }} {{ professor.sobrenome }}
            </router-link>
            <td>
              {{professor.qtdAlunos}}
            </td>
          </tr>
        </tbody>
        <tfoot v-else>
          <tr>
            <td colspan="3">Nenhum Aluno encontrado</td>
          </tr>
        </tfoot>
      </table>
    </div>
  </div>
</template>

<script>
import Titulo from "../_Shared/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      Professores: [],
      Alunos: []
    };
  },
  created() {
    this.$http.get('http://localhost:3000/alunos')
              .then(res => res.json())
              .then(alunos => {
                this.Alunos = alunos,
                this.carregarProfessores();
              })
  },
  props: {},
  methods: {
    pegarQtdAlunosPorProfessor(){
      this.Professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.Alunos.filter(aluno => aluno.professor.id == professor.id).length
        }
        this.Professores[index] = professor;
      });
    },

    carregarProfessores() {
       this.$http
      .get("http://localhost:3000/professores")
      .then((res) => res.json())
      .then(professores => {
        this.Professores = professores;
        this.pegarQtdAlunosPorProfessor();
      }); 
    }
  },
};
</script>

<style lang="scss" scoped></style>
