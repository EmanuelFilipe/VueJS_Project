<template>
    <div>
        <!-- :texto e :btnVoltar são parametros declarados no componente Titulo.vue -->
        <Titulo :texto="`Aluno: ${aluno.nome}`" :btnVoltar="false">
          <button class="btn btnEditar" @click="editar()">Editar</button>  
        </Titulo>
 
        <table id="table">
            <tbody>
                <tr>
                    <td class="colPequeno">Matrícula:</td>
                    <td>
                        <label>{{aluno.id}}</label>
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Nome:</td>
                    <td>
                        <label>{{aluno.nome}}</label>
                        <input v-model="aluno.nome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Sobrenome:</td>
                    <td>
                        <label>{{aluno.sobrenome}}</label>
                        <input v-model="aluno.sobrenome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Data Nascimento:</td>
                    <td>
                        <label>{{aluno.dataNasc}}</label>
                        <input v-model="aluno.dataNasc" type="text" />
                    </td>
                </tr>
                <tr>
                    <td class="colPequeno">Professor:</td>
                    <td>
                        <label>{{aluno.professor.nome}}</label>
                        <select v-model="aluno.professor">
                            <option v-for="(professor, index) in Professores" 
                                :key="index" v-bind:value="professor" >
                                {{professor.nome}}
                            </option>
                        </select>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import Titulo from '../_Shared/Titulo'

    export default {
        components: {
            Titulo
        },
        data() {
            return {
                Professores: [],
                aluno: {},
                id: this.$route.params.id
            }
        },
        created() {
            this.$http.get('http://localhost:3000/alunos/' + this.id)
                      .then(res => res.json())
                      .then(aluno => this.aluno = aluno) //alunos é o retorno da linha acima 'res.json()'

            this.$http.get("http://localhost:3000/professores")
                      .then((res) => res.json())
                      .then(professores => {
                            this.Professores = professores;
                       }); 
        },
        methods: {
            editar(){
                alert('teste')
            }
        },
    }
</script>

<style scoped>
    .btnEditar{
        float: right;
        background-color: rgb(76,186,249);
    }
    .colPequeno{
        width: 20%;
        text-align: right;
        background-color: rgb(125, 217, 245);
        font-weight: bold;
    }

    input, select {
        margin: 0;
        padding: 5px 10px;
        font-size: 0.9em;
        font-family: Montserrat;
        border: 1px solid silver;
        border-radius: 5px;
        background-color: rgb(245,245,245);
        width: 95%;
    }

    select {
        height: 38px;
        width: 100%;
    }
</style>