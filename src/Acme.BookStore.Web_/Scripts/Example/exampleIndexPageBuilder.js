import { createApp } from "vue";

import { createVuetify } from "vuetify";
import * as components from "vuetify/components";
import * as directives from "vuetify/directives";

import "vuetify/styles";

import example from "../../Vue/example.vue";

const app = createApp();

const vuetify = createVuetify({
	//components: {
	//	...components,
	//},
	//directives:
	//{}
});

app.use(vuetify);

app.component("example", example);

app.mount("#myApp");