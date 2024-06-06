import { client } from "@/app/shared/api/apiClient";
import { RecipesReadDto } from "@/app/shared/api/recipes/model";

export const searchRecipe = async (query: string): Promise<RecipesReadDto[]> => {
    const { data } = await client<RecipesReadDto[]>(`/searchRecipe/${query}`);

    return data;
}