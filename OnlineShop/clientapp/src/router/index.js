import Vue from 'vue'
import VueRouter from 'vue-router'
import HelloWorld from './../components/HelloWorld.vue'
import vCatalog from './../components/Catalog/v-catalog.vue'
import vAdminPanel from './../components/Admin/v-admin.vue'

Vue.use(VueRouter)

export default new VueRouter({
    routes: [
        {
            path: "",
            component: HelloWorld,
        },
        {
            path: "/catalog",
            component: vCatalog,
        },
        {
            path: "/admin",
            component: vAdminPanel
        }
    ]
})

