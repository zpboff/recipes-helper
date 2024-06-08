import { PageLayout } from "@/app/layouts/page-layout/ui";
import { Heading, Flex } from "@radix-ui/themes";
import styles from './page.module.scss';
import { RecipeList } from "./widgets/recipe-list";

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
