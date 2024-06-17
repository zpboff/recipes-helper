import { Maybe } from "@/core/utils/maybe";
import { ISearchRecipeRepository } from "@/domain/repositories/ISearchRecipeRepository";
import { client } from "@/infrastructure/http/client";
import RecipePage from "../../../../app/recipe/[id]/page";

export const search = async (query: string): Promise<Maybe<Recipe[]>> => {
    try {
        const { data } = await client.get<Recipe[]>(`/searchRecipe/${query}`);

        return Maybe.from(data);

    }
    catch(error: any) {
        return Maybe.nothing();
    }
}

export const searchRecipeRepository: ISearchRecipeRepository = { search } 