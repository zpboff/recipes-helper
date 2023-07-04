import { FastifyInstance } from 'fastify'

export function useRegistrationRoute(fastify: FastifyInstance) {
    fastify.get('/registration', async (req, res) => {
        return 'registration'
    });
}