import { PageLayout } from "@/application/layouts/page-layout";
import { Heading, Flex } from "@radix-ui/themes";
import styles from './home.module.scss';
import { RecipeList } from "@/application/recipe-list";

export const metadata = {
    title: 'Главная - Подбор рецептов',
    description: 'Поиск рецептов по ингредиентам',
}

export default function Home() {
    return (
        <PageLayout>
            <Flex className={styles.page} justify="center" direction="column">
              <Heading size="7" className={styles.heading}>Новые рецепты</Heading>
              <RecipeList />
            </Flex>
        </PageLayout>
    )
  }