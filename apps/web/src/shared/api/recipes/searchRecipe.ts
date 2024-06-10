import { client } from "@/shared/api/apiClient";
import { RecipesReadDto } from "@/shared/api/recipes/model";

export const searchRecipe = async (query: string): Promise<RecipesReadDto[]> => {
    const { data } = await client<RecipesReadDto[]>(`/searchRecipe/${query}`);

    return data;
}