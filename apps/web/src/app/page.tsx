import { PageLayout } from "@/app/layouts/page-layout/ui";
import { Heading, Flex } from "@radix-ui/themes";
import styles from './page.module.scss';
import { ProductList } from "./widgets/product-list";

export const metadata = {
    title: 'Главная - Подбор рецептов',
    description: 'Поиск рецептов по ингредиентам',
}

export default function Home() {
  return (
      <PageLayout>
          <Flex className={styles.page} justify="center" direction="column">
            <Heading size="7" className={styles.heading}>Рецепты</Heading>
            <ProductList />
          </Flex>
      </PageLayout>
  )
}
