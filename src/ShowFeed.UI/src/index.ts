import './index.css';
import * as m from 'mithril';

import LayoutComponent from 'layoutComponent';
import SeriesComponent from 'features/series/seriesComponent';

m.route(document.body, '/series', {
  '/series': { render: () => m(LayoutComponent, m(SeriesComponent)) }
});