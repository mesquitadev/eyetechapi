const routes = [
  { path: '', component: () => import('./pages/dashboard'), name: 'dashboard', meta: { auth: true } },
  { path: '/moradores', component: () => import('./pages/morador'), name: 'index.morador', meta: { auth: true } },
  { path: '/moradores/novo', component: () => import('./pages/morador/form'), name: 'cadastrar.morador', meta: { auth: true } },
  { path: '/moradores/editar/:id', component: () => import('./pages/morador/form'), name: 'editar.morador', meta: { auth: true } },
  { path: '/Apartamentos', component: () => import('./pages/apartamento'), name: 'index.apartamento', meta: { auth: true } },
  { path: '/Apartamentos/novo', component: () => import('./pages/apartamento/form'), name: 'cadastrar.apartamento', meta: { auth: true } },
  { path: '/Apartamentos/editar/:id', component: () => import('./pages/apartamento/form'), name: 'editar.apartamento', meta: { auth: true } },
  { path: '/veiculos', component: () => import('./pages/veiculos'), name: 'index.veiculo', meta: { auth: true } },
  { path: '/veiculos/novo', component: () => import('./pages/veiculos/form'), name: 'cadastrar.veiculo', meta: { auth: true } },
  { path: '/veiculos/editar/:id', component: () => import('./pages/veiculos/form'), name: 'editar.veiculo', meta: { auth: true } },
  { path: '/visitantes', component: () => import('./pages/visitantes'), name: 'index.visitante', meta: { auth: true } },
  { path: '/visitantes/novo', component: () => import('./pages/visitantes/form'), name: 'cadastrar.visitante', meta: { auth: true } },
  { path: '/visitantes/editar/:id', component: () => import('./pages/visitantes/form'), name: 'editar.visitante', meta: { auth: true } },
  { path: '/perfis', component: () => import('./pages/perfis'), name: 'index.perfil', meta: { auth: true } },
  { path: '/perfis/novo', component: () => import('./pages/perfis/form'), name: 'cadastrar.perfil', meta: { auth: true } },
  { path: '/perfis/editar/:id', component: () => import('./pages/perfis/form'), name: 'editar.perfil', meta: { auth: true } },
  { path: '/usuarios', component: () => import('./pages/usuarios'), name: 'index.usuario', meta: { auth: true } },
  { path: '/usuarios/novo', component: () => import('./pages/usuarios/form'), name: 'cadastrar.usuario', meta: { auth: true } },
  { path: '/usuarios/editar/:id', component: () => import('./pages/usuarios/form'), name: 'editar.usuario', meta: { auth: true } },
  { path: '/vigilancia', component: () => import('./pages/vigilancia'), name: 'index.vigilancia', meta: { auth: true } },
  { path: '/cameras', component: () => import('./pages/camera'), name: 'index.camera', meta: { auth: true } },
  { path: '/cameras/editar/:id', component: () => import('./pages/camera/form'), name: 'editar.camera', meta: { auth: true } },
  { path: '/cameras/novo', component: () => import('./pages/camera/form'), name: 'cadastro.camera', meta: { auth: true } },
  { path: '/cliente', component: () => import('./pages/cliente'), name: 'index.cliente', meta: { auth: true } }
]

export default routes
