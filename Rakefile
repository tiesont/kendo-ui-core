require "bundler/setup"
require "uglifier"
require 'rake/clean'
$LOAD_PATH << File.join(File.dirname(__FILE__), "build")
require 'merge'

JS = FileList['src/kendo*.js']
        .include("src/kendo.editor.js")
        .include("src/kendo.aspnetmvc.js")

MIN_JS = JS.sub(/src\/(.+)\.js/, "dist/js/\\1.min.js")

CLEAN.include(MIN_JS)


directory 'dist/js'

rule ".min.js" => [ lambda { |target| "src/#{ File.basename(target, '.min.js') }.js" } ] do |t|
    File.open(t.name, "w") do |file|
        puts "Compressing #{t.source} to #{t.name}\n"
        file.write Uglifier.new.compile(File.read(t.source))
    end
end

merge "src/kendo.editor.js" => [
    "src/editor/main.js",
    "src/editor/dom.js",
    "src/editor/serializer.js",
    "src/editor/range.js",
    "src/editor/system.js",
    "src/editor/inlineformat.js",
    "src/editor/formatblock.js",
    "src/editor/linebreak.js",
    "src/editor/lists.js",
    "src/editor/link.js",
    "src/editor/image.js",
    "src/editor/components.js",
    "src/editor/indent.js",
    "src/editor/viewhtml.js",
    "src/editor/pendingformats.js",
]

merge "src/kendo.aspnetmvc.js" => [
    "src/aspnetmvc/kendo.data.aspnetmvc.js",
    "src/aspnetmvc/kendo.combobox.aspnetmvc.js",
    "src/aspnetmvc/kendo.validator.aspnetmvc.js"
]

desc('Create kendo.editor.js')
task :editor => "src/kendo.editor.js"

desc('Minify the JavaScript files')
task :minify_js => ["dist/js", MIN_JS].flatten

desc('Build all Kendo UI distributions')
task :default => [:minify_js]
