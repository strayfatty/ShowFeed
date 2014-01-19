window.relativeDay = function(date, offset) {
    return new Date(date.getFullYear(), date.getMonth(), date.getDate() + offset);
};
