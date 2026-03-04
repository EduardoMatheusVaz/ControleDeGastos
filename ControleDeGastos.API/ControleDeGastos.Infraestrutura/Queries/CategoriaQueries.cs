namespace ControleDeGastos.Infraestrutura.Queries
{
    public class CategoriaQueries
    {
        public static string ObtemCategoriaPeloId(int id)
        {
            return $@"
                SELECT *, 
                        CASE
                            WHEN Finalidade = 1 THEN 'Despesa'
                            WHEN Finalidade = 2 THEN 'Receita'
                            WHEN Finalidade = 3 THEN 'Ambas'
                        END AS Finalidade
                FROM tb_Categoria
                WHERE IdCategoria = {id};"
            ;
        }

        public static string ObtemTodasCategorias()
        {
            return $@"
                SELECT *, 
                        CASE
                            WHEN Finalidade = 1 THEN 'Despesa'
                            WHEN Finalidade = 2 THEN 'Receita'
                            WHEN Finalidade = 3 THEN 'Ambas'
                        END AS Finalidade
                FROM tb_Categoria;
            ";
        }
    }
}
