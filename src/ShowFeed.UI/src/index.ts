import './index.css';
import * as m from 'mithril';

import LayoutComponent from 'layoutComponent';
import SeriesComponent from 'features/series/seriesComponent';
import FollowsComponent from 'features/follows/followsComponent';

m.route(document.body, '/series', {
  '/series': { render: () => m(LayoutComponent, m(SeriesComponent)) },
  '/follows': { render: () => m(LayoutComponent, m(FollowsComponent)) }
});