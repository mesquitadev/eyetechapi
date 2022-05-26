
import app from '@root/application/app/routes'
import auth from '@root/application/auth/routes'

const routes = [
  {
    path: '/auth',
    component: () => import('@application/auth/main.vue'),
    children: auth
  },
  {
    path: '/',
    meta: { auth: true },
    component: () => import('@root/layouts/layout.vue'),
    children: app
  }
]

// routes.push(app)
// routes.push(auth)

// Always leave this as last one
if (process.env.MODE !== 'ssr') {
  routes.push({
    path: '*',
    component: () => import('pages/Error404.vue')
  })
}
export default routes
