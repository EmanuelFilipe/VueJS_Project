<template>
  <div v-if="!loading">
    <!-- :texto e :btnVoltar são parametros declarados no componente Titulo.vue -->
    <Titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="editar()">
        Editar
      </button>
    </Titulo>

    <table id="table">
      <tbody>
        <tr>
          <td class="colPequeno">Matrícula:</td>
          <td>
            <label>{{ aluno.id }}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-show="visualizando">{{ aluno.nome }}</label>
            <input v-show="!visualizando" v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-show="visualizando">{{ aluno.sobrenome }}</label>
            <input
              v-show="!visualizando"
              v-model="aluno.sobrenome"
              type="text"
            />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Data Nascimento:</td>
          <td>
            <label v-show="visualizando">{{ aluno.dataNasc }}</label>
            <input
              v-show="!visualizando"
              v-model="aluno.dataNasc"
              type="text"
            />
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Professor:</td>
          <td>
            <label v-show="visualizando">{{ aluno.professor.nome }}</label>
            <select v-show="!visualizando" v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in Professores"
                :key="index"
                v-bind:value="professor.id"
              >
                {{ professor.nome }}
              </option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button @click="salvar(aluno)" class="btn btnSalvar">Salvar</button>
        <button @click="cancelar()" class="btn btnCancelar">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import Titulo from "../_Shared/Titulo";

export default {
  props: {},
  components: {
    Titulo,
  },
  data() {
    return {
      Professores: [],
      aluno: {},
      id: this.$route.params.id,
      visualizando: true,
      loading: true,
    };
  },
  created() {
      this.carregarProfessor();

  },
  methods: {
    carregarProfessor() {
      this.$http
        .get("http://localhost:5000/api/professor")
        .then((res) => res.json())
        .then((professores) => {
          this.Professores = professores;
          this.carregarAluno();
        });
    },
    carregarAluno() {
      this.$http
        .get(`http://localhost:5000/api/aluno/${this.id}`)
        .then(res => res.json())
        .then(aluno => {
            this.aluno = aluno
            this.loading = false;
        }); //alunos é o retorno da linha acima 'res.json()'
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(aluno) {
      let _alunoEditado = {
        id: aluno.id,
        nome: aluno.nome,
        sobrenome: aluno.sobrenome,
        dataNasc: aluno.dataNasc,
        professorid: aluno.professor.id,
      };

      this.$http
        .put(`http://localhost:5000/api/aluno/${_alunoEditado.id}`,_alunoEditado)
        .then(res=> res.json())
        .then(aluno = this.aluno = aluno)
        .then(() => this.visualizando = true);

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    },
  },
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btnCancelar {
  float: left;
  background-color: red;
}
.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0;
  padding: 5px 10px;
  font-size: 0.9em;
  font-family: Montserrat;
  border: 1px solid silver;
  border-radius: 5px;
  background-color: rgb(245, 245, 245);
  width: 95%;
}

select {
  height: 38px;
  width: 100%;
}
</style>
