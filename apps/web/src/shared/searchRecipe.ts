import { RecipesReadDto } from "@/infrastructure/dto/RecipesReadDto";
import { client } from "@/infrastructure/http/client";

export const searchRecipe = async (query: string): Promise<RecipesReadDto[]> => {
    const { data } = await client<RecipesReadDto[]>(`/searchRecipe/${query}`);

    return data;
}