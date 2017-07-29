import './layoutComponent.css';
import * as m from 'mithril';

const LayoutComponent: m.FactoryComponent<any> = function () {
  return {
    view: render
  };

  function render(vnode: m.Vnode<any>) {
    return [
      m('h1', 'ShowFeed'),
      m('div', vnode.children)
    ];
  }
};

export default LayoutComponent;