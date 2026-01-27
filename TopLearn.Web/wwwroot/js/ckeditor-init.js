// ckeditor-init.js - ساده‌ترین نسخه

async function initCKEditor(selector) {
    try {
        const {
            ClassicEditor,
            Essentials,
            Alignment,
            Heading,
            List,
            Link,
            AutoLink,
            Paragraph,
            ListProperties,
            Bold,
            Italic,
            Font,
            Indent,
            IndentBlock,
            CodeBlock,
            Table,
            TableToolbar
        } = await import('/ckeditor5/ckeditor5.js');

        const element = document.querySelector(selector);
        if (!element) return null;

        const editor = await ClassicEditor.create(element, {
            licenseKey: 'GPL',
            language: 'fa',
            plugins: [Essentials, Alignment, Heading, Paragraph, Bold, Italic,
                Font, Indent, IndentBlock, CodeBlock, List, ListProperties,
                AutoLink, Link, Table, TableToolbar],
            toolbar: [
                'undo', 'redo', '|',
                'heading', '|',
                'alignment', 'bold', 'italic', '|',
                'fontSize', 'fontFamily', 'fontColor', 'fontBackgroundColor', '|',
                'outdent', 'indent', 'bulletedList', 'numberedList', 'codeBlock',
                '|', 'insertTable', 'link'
            ],
            list: {
                properties: {
                    styles: true,
                    startIndex: true,
                    reversed: true
                }
            }
        });

        return editor;
    } catch (error) {
        console.error('خطا در راه‌اندازی CKEditor:', error);
        return null;
    }
}

// ایجاد متغیر global برای دسترسی آسان
window.initCKEditor = initCKEditor;