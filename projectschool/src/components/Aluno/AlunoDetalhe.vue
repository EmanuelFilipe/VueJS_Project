<template>
    <div>
        <Titulo :texto="`Aluno: ${aluno.nome}`" />

        <table>
            <tbody>
                <tr>
                    <td class="colPequeno">Matrícula:</td>
                    <td>
                        <label>{{aluno.id}}</label>
                    </td>
                </tr>
                <tr>
                    <td>Nome:</td>
                    <td>
                        <label>{{aluno.nome}}</label>
                        <input v-model="aluno.nome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>Sobrenome:</td>
                    <td>
                        <label>{{aluno.sobrenome}}</label>
                        <input v-model="aluno.sobrenome" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>Data Nascimento:</td>
                    <td>
                        <label>{{aluno.dataNasc}}</label>
                        <input v-model="aluno.dataNasc" type="text" />
                    </td>
                </tr>
                <tr>
                    <td>Professor:</td>
                    <td>
                        <label>{{aluno.professor.nome}}</label>
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
                aluno: {},
                id: this.$route.params.id
            }
        },
        created() {
            this.$http.get('http://localhost:3000/alunos/' + this.id)
                      .then(res => res.json())
                      .then(aluno => this.aluno = aluno) //alunos é o retorno da linha acima 'res.json()'
        },
        methods: {
            
        },
    }
</script>

<style scoped>

</style>