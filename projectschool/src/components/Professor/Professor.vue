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
            <td>{{professor.id}}</td>
            <td>{{professor.nome}} {{professor.sobrenome}}</td>
            <td>
              3
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
  import Titulo from '../_Shared/Titulo'

    export default {
      components:{
        Titulo
      },
      data(){
        return {
          Professores : [
            { id: 1, nome: 'Chico'},
            { id: 2, nome: 'Joao'},
            { id: 3, nome: 'Teresa'}
          ]
        }
      }
    }
</script>

<style lang="scss" scoped>

</style>