import './seriesComponent.css';
import * as m from 'mithril';

import SeriesService from 'features/series/seriesService';

export default class SeriesComponent implements m.ClassComponent {
  oninit() {
    SeriesService.list('hallo', 10, 20);
    return SeriesService.details('hallo');
  }

  view() {
    return m('h1', 'Series');
  }
}