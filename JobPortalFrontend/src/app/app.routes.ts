import { Routes } from '@angular/router';

export const routes: Routes = [

    { path: '',
  loadComponent: () => import('./home-page/home-page.component').then(m => m.HomePageComponent)
   }, // Default route
   { path: 'register',
  loadComponent: () => import('./register-page/register-page.component').then(m => m.RegisterPageComponent)
   },
   { path: 'login',
  loadComponent: () => import('./login-page/login-page.component').then(m => m.LoginPageComponent)
   },
   { path: 'about',
   loadComponent: () => import('./about-page/about-page.component').then(m => m.AboutPageComponent)
    },
    { path: 'adminPanel/:id',
    loadComponent: () => import('./admin-panel/admin-panel.component').then(m => m.AdminPanelComponent)
     },
     {
        path:'Home/:id',
        loadComponent: () =>import('./job-detail-page/job-detail-page.component').then(m=>m.JobDetailPageComponent)
      }
    
];
